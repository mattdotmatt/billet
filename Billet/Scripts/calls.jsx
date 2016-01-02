var React = require('react');

module.exports = React.createClass({

    render: function () {
        console.log(this.props.calls);
        return (
                        <div className="breakdown">
                <span id="calls-breakdown">Your Calls Breakdown</span>
  <table className="table table-striped">
                <thead>
                    <tr>
                        <th>Called</th>
                        <th>Cost</th>
                        <th>Duration</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        this.props.calls.map(function (c) {
                            return <tr><td>{c.called}</td><td>£{c.cost.toFixed(2)}</td><td>{c.duration}</td></tr>
                        })
                    }
                </tbody>
  </table>
                        </div>
        )
    }
});
