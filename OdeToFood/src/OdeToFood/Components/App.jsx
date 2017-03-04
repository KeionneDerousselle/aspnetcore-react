import React, {Component} from 'react';
import 'whatwg-fetch';

function ErrorMessage(props) {
    return <h2>{props.errorMessage}</h2>;
}

function RestaurantsContent(props) {
    let restaurants = props.restaurants.map((restaurant) =>
        <li key={restaurant.id}>{restaurant.name}</li>
        );

    return(
        <div>
            <h2>{props.currentMessage}</h2>
            <ul>{restaurants}</ul>
        </div>
    );
}

function AppContent(props) {
    const hasErrored = props.errorMessage;
    if (hasErrored) {
        return <ErrorMessage errorMessage={props.errorMessage}/>;
    }
    return <RestaurantsContent currentMessage={props.currentMessage} restaurants={props.restaurants}/>;
}


export default class App extends Component{
    
    constructor(props){
        super(props);

        this.state = {
            currentMessage: "",
            restaurants: [],
            responseErrorMessage: ""
        }
    }

    componentDidMount() {
        fetch('http://localhost:55257/home/getrestaurants')
            .then((response) => {
                if (response.status !== 200) {
                    this.setState({ responseErrorMessage: response.statusText });
                }
                return response.text();
            }).then((body) => {
                const data = JSON.parse(body);
                this.setState(data);
            });
    }

    componentWillUnmount(){
        this.setState({});
    }

    render(){
       return ( 
            <div>
               <AppContent 
                    errorMessage={this.state.responseErrorMessage}
                    currentMessage ={this.state.currentMessage}
                    restaurants = {this.state.restaurants} />
            </div>
            );
    }
};