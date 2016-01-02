var React = require('react');

var Rentals = require('./rentals');
var BuyAndKeeps = require('./buy-and-keeps');

module.exports = React.createClass({

    render: function () {
        return (
            <div className="breakdown">
                <span id="skystore-breakdown">Your Sky Store Breakdown</span>
                <BuyAndKeeps buyandkeep={this.props.skystore.buyandkeep} />
                <Rentals rentals={this.props.skystore.rentals} />
            </div>
        )
    }
});

