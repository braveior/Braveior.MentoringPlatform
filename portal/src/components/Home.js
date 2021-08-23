

import Container from '@material-ui/core/Container';
import { makeStyles } from '@material-ui/core/styles';
import Grid from '@material-ui/core/Grid';
import Paper from '@material-ui/core/Paper';
import Typography from '@material-ui/core/Typography';
import Avatar from '@material-ui/core/Avatar';
import Button from '@material-ui/core/Button';
import Chip from '@material-ui/core/Chip';
import StarsIcon from '@material-ui/icons/Stars';
import { Link } from 'react-router-dom'
import Box from '@material-ui/core/Box';
import useFetch from "../useFetch";
import Backdrop from '@material-ui/core/Backdrop';
import CircularProgress from '@material-ui/core/CircularProgress';
import { useState, useEffect } from 'react'
import Badge from '@material-ui/core/Badge';
const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
  },
  paper: {
    padding: theme.spacing(2),
    margin: 'auto',
    maxWidth: 350,
  },
  image: {
    width: 175,
    height: 175,
  },
  img: {
    margin: 'auto',
    display: 'block',
    maxWidth: '100%',
    maxHeight: '100%',
  },
  large: {
    width: theme.spacing(7),
    height: theme.spacing(7),
  },
  chipColor: {
    color: 'white',
    background: '#007991',
  },
  leadColor: {
    color: 'white',
    background: 'black',
  },

}));

export default function Home() {
  const { error, isPending, data: profiles } = useFetch('http://7090-48476.el-alt.com/api/profile/getprofiles')
  const [open, setOpen] = useState(false);
  const classes = useStyles();
  const handleClose = () => {
    setOpen(false);
  };
  return (
    <Container maxWidth="lg">
      <Box p={2}>
        <Grid container spacing={3}>
          {error && <div>{error}</div>}
          {profiles && profiles.map((profile) => (
            <Grid key={profile.userId} item>
              <Paper className={classes.paper}>
                <Grid container spacing={2}>
                  <Grid item>
                    <Avatar alt="" src={"/static/images/avatar/" + profile.userId + ".jpg"} className={classes.large} />
                    <Grid item xs>
                      {profile.isLeader == true && <Chip label={"Leader"} className={classes.leadColor} color="primary" size="small" ></Chip>}
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
                      <Chip icon={<StarsIcon />} label={profile.points + " pts"} className={classes.chipColor} color="primary" size="small" > </Chip>
                    </Grid>
                  </Grid>
                </Grid>
              </Paper>
            </Grid>
          ))}
        </Grid>
      </Box>
      <Backdrop className={classes.backdrop} open={isPending} onClick={handleClose}>
        <CircularProgress color="inherit" />
      </Backdrop>
    </Container>
  )
}
