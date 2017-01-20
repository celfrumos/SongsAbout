var Hello = React.createClass({
    render: function () {
        return <p>Hello World</p>;
    }
});

ReactDOM.render(<Hello />, document.getElementById('app'));