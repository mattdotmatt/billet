var React = require('react');

var PersonalDetails = require('./personal-details');
var BillSummary = require('./bill-summary');

module.exports = React.createClass({

    render: function () {

        return <div className="container">
            <PersonalDetails />
            <BillSummary billSummary={this.props.billSummary} accountId={this.props.accountId} />
        </div>
    }
});