import Container from '@mui/material/Container';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import Grid from '@mui/material/Grid';
import Typography from '@mui/material/Typography';
import Divider from '@mui/material/Divider';
import Paper from '@mui/material/Paper';
import Box from '@mui/material/Box';
import { AuthContext } from "../App";
import React from 'react';
import { useState } from 'react';


export default function Login () {

 const { dispatch } = React.useContext(AuthContext);

const [email, setEmail] = useState(null);
  const [password, setPassword] = useState(null);

const onLogin = () => {

    fetch('https://student.braveior.com/api/Login/Login', {
      method: 'POST',
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({"email":"sree@email.com","password":"password"})
    }).then(res => {
        if (!res.ok) { // error coming back from server
          throw Error('could not fetch the data for that resource');
        } 
        return res.json();
      })
      .then(data => {
        console.log(data);
        dispatch({
            type: "LOGIN",
            payload: {
        isAuthenticated: true,
        firstName: data.firstName
      }
        })
      })
      .catch(err => {
          // auto catches network / connection error
         // setError('API call Error !!');
      })



  

}




const handleEmailChange = (event) => {
    setEmail(event.target.value);
  };

const handlePasswordChange = (event) => {
    setPassword(event.target.value);
  };


  return (
<>
<Container maxWidth="sm">
<Box m={4}>
<Paper>
<Grid container direction="column">
 <Grid item>
 <Box m={2}>
<TextField
          id="txtEmail"
          label="Email"
          variant="outlined"
          name="email"
          onChange={handleEmailChange}
          value={(email && email) || ''}
        />
</Box>
</Grid>
 <Grid item>
<Box m={2}>
<TextField
          id="txtPassword"
          label="Password"
          variant="outlined"
          name="password" 
          type="password"
          onChange={handlePasswordChange}
          value={(password && password) || ''}
/>
</Box>
</Grid>
 <Grid item>
<Box m={2}>
<Button disabled={!(email && password)}  variant="contained" onClick={onLogin}>Login</Button>
</Box>
</Grid>
</Grid>
</Paper>
</Box>
</Container>
</>
  );
}