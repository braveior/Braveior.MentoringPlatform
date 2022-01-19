import Container from '@mui/material/Container';
import Grid from '@mui/material/Grid';
import Paper from '@mui/material/Paper';
import Typography from '@mui/material/Typography';
import Avatar from '@mui/material/Avatar';
import Button from '@mui/material/Button';
import Chip from '@mui/material/Chip';
import StarsIcon from '@mui/icons-material/Stars';
import { Link } from 'react-router-dom'
import Box from '@mui/material/Box';
import Backdrop from '@mui/material/Backdrop';
import CircularProgress from '@mui/material/CircularProgress';
import { useState, useEffect } from 'react'
import Badge from '@mui/material/Badge';

export default function HallOfFame () {
const [open, setOpen] = useState(false);
const [error,setError] = useState(null);
const [isPending, setIsPending] = useState(false);
const [profiles, setProfiles] = useState([]);
const handleClose = () => {
    setOpen(false);
  };

useEffect(() => {
   fetchProfiles();
  }, []);

const fetchProfiles = () => {

      fetch('https://student.braveior.com/api/profile/getprofiles')
      .then(res => {
        if (!res.ok) { // error coming back from server
          throw Error('could not fetch the data for that resource');
        } 
        return res.json();
      })
      .then(data => {
        setProfiles(data);
      })
      .catch(err => {
          // auto catches network / connection error
         // setError('API call Error !!');
      })

}


return (
<>

<Container maxWidth="xl">
      <Box p={2}>
        <Grid container spacing={3}>
          {error && <div>{error}</div>}
          {profiles && profiles.map((profile) => (
            <Grid key={profile.userId} item>
              <Paper sx={{ padding:2 ,margin: 'auto', maxWidth: 350}}>
                <Grid container spacing={2}>
                  <Grid item>
                    <Avatar alt="" src={"https://student.braveior.com/images/" + profile.userId + ".jpg"} sx={{width:56,height:56 }} />
                    <Grid item xs>
                      {profile.isLeader == true && <Chip label={"Leader"} sx={{color:'white',background:'black'}} color="primary" size="small" />}
                    </Grid>
                  </Grid>
                  <Grid item xs container direction="column">
                    <Grid item xs>
                      <Typography gutterBottom variant="subtitle1">
                        {profile.studentName}
                      </Typography>
                    </Grid>
                    <Grid item xs>
                      <Typography variant="body2" gutterBottom>
                        {profile.insitutionName}
                      </Typography>
                    </Grid>
                    <Grid item>
                      <Link to={"/detail?userId=" + profile.userId}>View Details</Link>
                    </Grid>
                  </Grid>
                  <Grid item direction="column">
                    <Grid item xs>
                      <Chip icon={<StarsIcon />} label={profile.points + " pts"} sx={{color:'white',background:'#007991'}} color="primary" size="small" /> 
                    </Grid>
                  </Grid>
                </Grid>
              </Paper>
            </Grid>
          ))}
        </Grid>
      </Box>
      <Backdrop sx={{ color: '#fff', zIndex: 125 }} open={isPending} onClick={handleClose}>
        <CircularProgress color="inherit" />
      </Backdrop>
    </Container>

</>
);
}