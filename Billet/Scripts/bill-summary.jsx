var React = require('react');
var moment = require('moment');

var Grid = require('react-bootstrap').Grid;
var Row = require('react-bootstrap').Row;
var Col = require('react-bootstrap').Col;

var Error = require('./error');

var CallBreakdown = require('./calls');
var Subscriptions = require('./subscriptions');
var SkyStore = require('./sky-store');

module.exports = React.createClass({

    getInitialState: function () {
        return {
            accountId: 0,
            showErrors: false,
            errorMessage: '',
            bill: null,
            detailsToShow: '',
        }
    },

    showDetailedSubscriptions: function () {
        if (this.state.bill === null) {
            this.loadDetailed();
        }

        this.setState({ detailsToShow: "showDetailedSubscriptions" });
    },

    showDetailedSkyStore: function () {
        if (this.state.bill === null) {
            this.loadDetailed();
        }

        this.setState({ detailsToShow: "showDetailedSkyStore" });
    },

    showDetailedCalls: function () {
        if (this.state.bill === null) {
            this.loadDetailed();
        }

        this.setState({ detailsToShow: "showDetailedCalls" });
    },

    loadDetailed: function () {

        xhr = new XMLHttpRequest();

        xhr.open('GET', encodeURI(currentDomain+'api/account/' + this.props.accountId + '/billbreakdown'));

        xhr.onload = function () {
            if (xhr.status === 200) {
                var b = JSON.parse(xhr.responseText);
                this.setState({ bill: b });
                return;
            }
            else if (xhr.status === 404) {
                this.setState({ showDetailed: false })
                return;
            } else if (xhr.status !== 200) {
                this.setState({ showDetailed: false })
                return;
            }
        }.bind(this);
        xhr.send();
    },

    render: function () {

        var dateFrom = moment(this.props.billSummary.from).format('LL')
        var dateTo = moment(this.props.billSummary.to).format('LL')

        var detailed;

        if (this.state.detailsToShow === "showDetailedSubscriptions") {
            detailed = <Subscriptions subscriptions={this.state.bill.package.subscriptions} />
        }
        if (this.state.detailsToShow === "showDetailedSkyStore") {
            detailed = <SkyStore skystore={this.state.bill.skystore} />
        }
        if (this.state.detailsToShow === "showDetailedCalls") {
            detailed = <CallBreakdown calls={this.state.bill.callcharges.calls} />
        }

        return <div id="bill-summary">
              <div id="bill-summary-title" >Your bill for period {dateFrom} to {dateTo}</div>
              <div>
              <Grid>
                <Row>
                    <Col md={3}>
                        <span className="billType">Total</span>
                        <div className="circle-total" id="total">
                            £{this.props.billSummary.total.toFixed(2)}
                        </div>
                    </Col>
                    <Col md={3}>
                        <span className="billType">Package</span>
                        <div className="circle" id="package" onClick={this.showDetailedSubscriptions}>
                            <div id="packageTotal">£{this.props.billSummary.packagetotal.toFixed(2)}</div> 
                            <div className="bill-summary-breakdown-details"><a href="#">see details</a></div>
                        </div>
                    </Col>
                     <Col md={3}>
                    <span className="billType">Sky store</span>
                        <div className="circle" id="skystore" onClick={this.showDetailedSkyStore}>
                            <div id="skystoreTotal">£{this.props.billSummary.skystoretotal.toFixed(2)}</div>
                            <div className="bill-summary-breakdown-details"><a href="#">see details</a></div>
                        </div>
                    </Col>
                     <Col md={3}>
                    <span className="billType">Calls</span>
                        <div className="circle" id="calls" onClick={this.showDetailedCalls}>
                            <div id="callsTotal">£{this.props.billSummary.callchargestotal.toFixed(2)}</div>
                            <div className="bill-summary-breakdown-details"><a href="#">see details</a></div>
                            </div>
                    </Col>
                </Row>
              </Grid>
                  {detailed}
              </div>
          </div>
    }
});
