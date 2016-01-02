var React = require('react');

module.exports = React.createClass({

    loadAccount: function (e) {
        this.props.accountId = this.refs.accountId.value
        this.props.setAccount(this.refs.accountId.value);
    },

    render: function () {

        return <div className="container">
          <div id="login-title">Please enter your account number and lets get going</div>
          <div id="login">
              <label for="accountId">Account number</label>
              <input id="txtAccountId" type="text" ref="accountId" />
              <button id="btnLogin" type="button" className="btn btn-success" onClick={this.loadAccount}>Login</button>
          </div>
        </div>
    }
});