import { BrowserRouter as Router, Route, Switch } from 'react-router-dom'
import { AuthContext } from "../src/App";
import React from "react";

import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import { Link } from 'react-router-dom'
import Grid from '@mui/material/Grid';
import logo from './images/halloffame.png'
export default function Header() {
  const { state, dispatch } = React.useContext(AuthContext);
  return (
    <AppBar sx={{ background: '#192b32' }} position="static">
      <Toolbar>
        <Grid container>
          <Grid item xs={3} >
            <img src={logo} width="150px" height="50px"></img>
          </Grid>
          <Grid item xs={7} />
          <Grid item xs={1} >
            <Link to='/' style={{ color: 'white' }}>Add Task</Link>
          </Grid>
          <Grid item xs={1} >
            {state.isAuthenticated && (
              <h1>Hi {state.firstName} (LOGOUT)</h1>
            )}
          </Grid>
        </Grid>
      </Toolbar>
    </AppBar>
  );
}