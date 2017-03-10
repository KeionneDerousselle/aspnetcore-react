import React from 'react';
import {render} from 'react-dom';
import App from './components/App.jsx';
import 'materialize-css';
import 'materialize-css/dist/css/materialize.min.css';
import './Styles/app.css';

render(

    <div>
        <App/>
    </div>,
    document.getElementById('root')
);