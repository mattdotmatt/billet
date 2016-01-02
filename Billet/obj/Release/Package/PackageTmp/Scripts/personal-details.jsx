var React = require('react');
var Error = require('./error');

var Grid = require('react-bootstrap').Grid;
var Row = require('react-bootstrap').Row;
var Col = require('react-bootstrap').Col;

module.exports = React.createClass({
    render: function () {
        return <div id="personal">
                <div id="personal-details-title" >Your details</div>
                <Grid>
                    <Row>
                        <Col md={2}><label>Account number</label> </Col>    <Col md={2}>123</Col>
                    </Row>
                    <Row>
                        <Col md={2}><label>Account name</label></Col>   <Col md={2}>A Person</Col>
                    </Row>
                    <Row>
                        <Col md={2}><label>Contact number</label></Col>    <Col md={2}>07952556222</Col>
                    </Row>
                    <Row>
                        <Col md={2}><label>Contact email</label></Col>     <Col md={2}>test@email.com</Col>
                    </Row>
                </Grid>
        </div>
    }
});