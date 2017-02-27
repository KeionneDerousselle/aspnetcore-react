import React, {Component} from 'react';
import 'whatwg-fetch';

export default class App extends Component{
    
    constructor(props){
        super(props);
        this.state = {
            currentState: "",
            restaurants: [],
            responseErrorMessage: ""
        }
    }

    componentDidMount() {
        fetch('http://localhost:55257/home/getrestaurantsfg')
            .then((response) => {
                if (response.status === 200) {
                    var data = JSON.parse(response.text());
                    this.setState(data);
                } else {
                    this.setState({ responseErrorMessage: response.statusText });
                }
            });
    }

    componentWillUnmount(){
        this.setState({});
    }

    render(){
        let restaurants = this.state.restaurants.map((restaurant) =>
            <li key={restaurant.id}>{restaurant.name}</li>
        );

        let errorMessage = this.state.responseErrorMessage;

        return ( 
            <div>
                <h3> {this.state.currentState} </h3>
                <ul>{restaurants}</ul>
            </div>
            );
    }
};