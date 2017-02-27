import React, {Component} from 'react';
import 'whatwg-fetch';

export default class App extends Component{
    
    constructor(props){
        super(props);
        this.state = {
            currentState: "",
            restaurants: []
        }
    }

    componentDidMount(){
        fetch('http://localhost:55257/home/getrestaurants')
           .then(function(response) {
               return response.text()
           }).then((b) => {
               var data = JSON.parse(b);
               this.setState(data);
           })
    }

    componentWillUnmount(){
        this.setState({});
    }

    render(){
        let restaurants = this.state.restaurants.map((restaurant) =>
            <li key={restaurant.id}>{restaurant.name}</li>
        );

        return ( 
            <div>
                <h3> {this.state.currentState} </h3>
                <ul>{restaurants}</ul>
            </div>
            );
    }
};