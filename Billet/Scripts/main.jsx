var React = require('react');
var ReactDOM = require('react-dom');

var Header = require('./header');
var Login = require('./login');
var Statement = require('./statement');
var Footer = require('./footer');
var Error = require('./error');

var Main = React.createClass({
    getInitialState: function () {
        return {
            accountId: 0,
            billSummary: {},
            showErrors: false,
            errorMessage: ''
        };
    },

    setAccountId: function (accountId) {
        xhr = new XMLHttpRequest();

        xhr.open('GET', encodeURI(currentDomain+'api/account/' + accountId + '/billsummary'));
        xhr.onload = function () {
            if (xhr.status === 200) {
                var summary = JSON.parse(xhr.responseText);
                this.setState({ showErrors: false, accountId: accountId, billSummary: summary });
                return;
            }
            else if (xhr.status === 404) {
                this.setState({ showErrors: true, errorMessage: "Darn, we can't find that account. Can you check and try again?" })
                return;
            } else if (xhr.status !== 200) {
                this.setState({ showErrors: true, errorMessage: "Darn, we can't find that account. Can you check and try again?" })
                return;
            }
        }.bind(this);
        xhr.send();
    },

    render: function () {

        var error;
        if (this.state.showErrors) {
            error = <Error errorMsg={this.state.errorMessage}/>
        }

        var panel;
        if (this.state.accountId === 0) {
            panel = <Login setAccount={this.setAccountId} />
        } else {
            panel = <Statement {...this.props} billSummary={this.state.billSummary} accountId={this.state.accountId} />
        }

        return (
            <div>
                <Header />
                <main>
                    <span id="bill-title">Manage your Sky bills and payments</span>
                    {error}
                    <div>
                        {panel}
                    </div>
                </main>
                <Footer />

            </div>
        )
    }
});

var homePage = React.createElement(Main);

ReactDOM.render(homePage, document.querySelector('.outer-wrapper'));
