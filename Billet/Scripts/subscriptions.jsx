var React = require('react');

module.exports = React.createClass({

    render: function () {
        return (
            <div className="breakdown">
                <span id="package-breakdown">Your Package Breakdown</span>
                <table className="table table-striped">
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Cost</th>
                            <th>Type</th>
                        </tr>
                    </thead>
                    <tbody>
                    {
                        this.props.subscriptions.map(function (c) {
                            return <tr><td>{c.name}</td><td>£{c.cost.toFixed(2)}</td><td>{c.type}</td></tr>
                        })
                    }
                        </tbody>
                </table>
            </div>
        )
    }
});