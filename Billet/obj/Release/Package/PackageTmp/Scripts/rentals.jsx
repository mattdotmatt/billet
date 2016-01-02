var React = require('react');

module.exports = React.createClass({

    render: function () {
        console.log(this.props.rentals[0]);
        return (
     <table className="table table-striped">
                <thead>
                    <tr>
                        <th>Title</th>
                        <th>Cost</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        this.props.rentals.map(function (c) {
                            return <tr><td>{c.title}</td><td>£{c.cost.toFixed(2)}</td></tr>
                        })
                    }
                </tbody>
     </table>
        )
    }
});
