# billet

Tech Test

## Getting the solution running

To get solution up and running:

* Clone
* Restore the js files in the Billet directory using "npm install --save-dev"
* Restore packages using nuget restore

Solution should now build, execute and have passing tests.

## Making changes

main.js and main.css are checked in and ready to run. However, any changes to the jsx or scss files will need to be built using gulp. There is a gulpfile.js in the root to do this.

## Using the site

The default is for the site to run under http://localhost/billet

The site asks for an account number. 123 will bring back data. Anything else should show an unknown account error message.
