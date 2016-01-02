var gulp = require('gulp');
var $ = require('gulp-load-plugins')({ lazy: true });
var source = require('vinyl-source-stream');
var browserify = require('browserify');
var watchify = require('watchify');
var reactify = require('reactify');
var babel = require('babel-core/register');
var sass = require('gulp-sass');

gulp.task('react', function () {
    log('Compiling React ==> JS');
    var bundler = browserify({
        entries: ['./scripts/main.jsx'],
        transform: [reactify],
        extensions: ['.jsx'],
        debug: true,
        cache: {},
        packageCache: {},
        fullPaths: true
    });

    function build(file) {
        if (file) log('recompiling ' + file);

        return bundler
            .bundle()
            .on('error', $.util.log.bind($.util, 'Browserify error'))
            .pipe(source('app.js'))
            .pipe(gulp.dest('./content/js'))
            .pipe($.livereload());
    };

    return build();
});

gulp.task('jsx-watcher', function () {
    $.livereload.listen();
    var bundler = watchify(browserify({
        entries: ['./scripts/main.jsx'],
        transform: [reactify],
        extensions: ['.jsx'],
        debug: true,
        cache: {},
        packageCache: {},
        fullPaths: true
    }));

    function build(file) {
        if (file) log('recompiling ' + file);

        return bundler
        .bundle()
        .on('error', $.util.log.bind($.util, 'Browserify error'))
        .pipe(source('app.js'))
        .pipe(gulp.dest('./content/js'))
        .pipe($.livereload());
    };

    build();
    bundler.on('update', build);
});

gulp.task('sass', function () {
    gulp.src('./sass/**/*.scss')
      .pipe(sass.sync().on('error', sass.logError))
      .pipe(gulp.dest('./content/css'));
});

gulp.task('sass-watch', function () {
    gulp.watch('./sass/**/*.scss', ['sass']);
});

gulp.task('default', ['jsx-watcher', 'sass-watch']);

//////////////////////////////////////////////////////////////////////


function log(msg) {
    if (typeof (msg) === 'object') {
        for (var item in msg) {
            if (msg.hasOwnProperty(item)) {
                $.util.log($.util.colors.yellow(msg[item]));
            }
        }
    } else {
        $.util.log($.util.colors.yellow(msg));
    }
}

function handleError(err) {
    $.util.beep();
    log(err);
};
