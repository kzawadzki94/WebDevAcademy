import React, { Component } from 'react';
import Loadable from 'react-loadable';
import '../node_modules/material-icons/iconfont/material-icons.css';
import './App.css';
import './styles/styles.css';

const Loading = () => <div>Loading...</div>;
const LinksPage = Loadable({
  loader: () => import('./containers/LinksContainer'),
  loading: Loading
});

class App extends Component {
  render() {
    return (
      <LinksPage />
    );
  }
}

export default App;
