import React from 'react';
import PropTypes from 'prop-types';
import Grid from '@mui/material/Grid';
import Paper from '@mui/material/Paper';
import Avatar from '@mui/material/Avatar';
import Container from '@mui/material/Container';
import Typography from '@mui/material/Typography';
import Button from '@mui/material/Button';
import Chip from '@mui/material/Chip';
import StarsIcon from '@mui/icons-material/Stars';
import Rating from '@mui/material/Rating';
import Box from '@mui/material/Box';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemText from '@mui/material/ListItemText';
import ListItemAvatar from '@mui/material/ListItemAvatar';
import ImageIcon from '@mui/icons-material/Image';
import WorkIcon from '@mui/icons-material/Work';
import MenuBookIcon from '@mui/icons-material/MenuBook';
import YouTubeIcon from '@mui/icons-material/YouTube';
import ForumIcon from '@mui/icons-material/Forum';
import HomeIcon from '@mui/icons-material/Home';
import { Link, useLocation } from 'react-router-dom'
import { useState, useEffect } from 'react'
import Backdrop from '@mui/material/Backdrop';
import CircularProgress from '@mui/material/CircularProgress';
import LinkedInIcon from '@mui/icons-material/LinkedIn';
import EmojiObjectsIcon from '@mui/icons-material/EmojiObjects';
import Divider from '@mui/material/Divider';
import Tabs from '@mui/material/Tabs';
import Tab from '@mui/material/Tab';
export default function Profile () {

function TabPanel(props) {
  const { children, value, index, ...other } = props;

  return (
    <div
      role="tabpanel"
      hidden={value !== index}
      id={`simple-tabpanel-${index}`}
      aria-labelledby={`simple-tab-${index}`}
      {...other}
    >
      {value === index && (
        <Box sx={{ p: 3 }}>
          {children}
        </Box>
      )}
    </div>
  );
}

TabPanel.propTypes = {
  children: PropTypes.node,
  index: PropTypes.number.isRequired,
  value: PropTypes.number.isRequired,
};

function a11yProps(index) {
  return {
    id: `simple-tab-${index}`,
    'aria-controls': `simple-tabpanel-${index}`,
  };
}

useEffect(() => {
   fetchProfiles();
  }, []);


const fetchProfiles = () => {

      fetch('https://student.braveior.com/api/profile/getprofile/1') 
      .then(res => {
        if (!res.ok) { // error coming back from server
          throw Error('could not fetch the data for that resource');
        } 
        return res.json();
      })
      .then(data => {
        setProfile(data);
      })
      .catch(err => {
          // auto catches network / connection error
         // setError('API call Error !!');
      })

}


const [value, setValue] = React.useState(0);
  //const { error, isPending, data: profile } = useFetch('http://7090-48476.el-alt.com/api/profile/getprofile/' + query.get('userId')) 
  const [error, setError] = React.useState(false);
  const [isPending, setIsPending] = React.useState(false);
  const [profile, setProfile] = React.useState(null);
  const preventDefault = (event) => event.preventDefault();
  const [open, setOpen] = React.useState(false);
  const handleClose = () => {
    setOpen(false);
  };
const handleChange = (event, newValue) => {
    setValue(newValue);
  };
return (
<>
  <Container maxWidth="lg">
      <Box p={1}><Link to="/"><Button variant="outlined">Back</Button></Link></Box>
      { error && <div>{ error }</div> }
      { profile && 
        <Paper elevation={1} >
        <Box p={4}>
<Grid container spacing={3}>
<Grid item xs={1} >
  <Avatar src={"https://student.braveior.com/images/1.jpg"} sx={{width:75,height:75}} />
  
</Grid>
<Grid item xs={11} container direction="column">
              <Typography gutterBottom variant="h5">
                {profile.studentName} 
              <a href={profile.linkedInLink} target="_blank"><LinkedInIcon sx={{color:'#0e76a8',background:'white'}} fontSize="large"/></a>
          
          <Chip icon={<StarsIcon/>} label={profile.points + " pts"} sx={{color:'white',background:'#007991'}}  color="primary" size="small" />
              </Typography>
              <Typography variant="subtitle1" gutterBottom>
                      {profile.insitutionName}
              </Typography>
              <Typography variant="subtitle2" gutterBottom>
                {profile.isLeader == true && <Chip label={"Leader"} sx={{color:'white',background: 'black'}} color="primary" size="small" ></Chip>}            
              </Typography>
</Grid>
              


</Grid>
              
              
          <Typography variant="h6" gutterBottom>
              About myself
          </Typography>
          <Typography variant="body2" gutterBottom sx={{width:'100%',maxWidth:800}}>
          {profile.description}
          </Typography>
          <Grid item >
            <Typography  variant="h6">Technology Confidence Meter</Typography>
          <Box sx={{maxWidth:500,position: 'relative', overflowY: 'scroll', overflowX: 'hidden', maxHeight: 150}}>
            {profile.userSkills && profile.userSkills.map(userSkill =>(
            <Grid container>  
              <Grid item xs={8}><Typography variant="subtitle2">{userSkill.skill && userSkill.skill.name}</Typography></Grid>
              <Grid item xs={4}><Rating name="read-only" value={userSkill.stars} readOnly />  </Grid>
            </Grid>
            ))}
          </Box>
          </Grid>
<br/>
<Divider variant="middle" />
<br/>
    <Typography variant="h5" gutterBottom>
        Student Events

            </Typography>    
   <Tabs
        value={value}
        indicatorColor="primary"
        textColor="primary"
        onChange={handleChange}
        aria-label="disabled tabs example"
      >
<Tab label="Challenges" {...a11yProps(0)}>
</Tab>
<Tab label="Group Discussion" {...a11yProps(1)}>
</Tab>
<Tab label="Blogs" {...a11yProps(2)}>
</Tab>
<Tab label="Vlogs" {...a11yProps(3)}>
</Tab>
</Tabs>

<TabPanel value={value} index={0}>
<List sx={{width: '100%', maxWidth: 800,position: 'relative', overflow: 'auto', maxHeight: 300,}}>
            {profile.studentWorkItems && profile.studentWorkItems.filter(studentWorkItem => studentWorkItem.type===4).map(ch =>(ch &&
      <ListItem>
        <ListItemAvatar>
          <a href={ch.assetUrl} target="_blank"><Avatar>
          <YouTubeIcon sx={{color : '#e62117',background: 'white',}}  fontSize="large"/>
          </Avatar></a>
        </ListItemAvatar>
        <ListItemText primary={
            <React.Fragment>
               <Typography variant="subtitle2" gutterBottom>
                 <a href={ch.assetUrl} target="_blank">{ch.challenge.name}</a> <Chip icon={<StarsIcon/>} label={ch.points + " pts"} sx={{color : 'white', background: '#007991'}}  color="primary" size="small" ><StarsIcon fontSize="small" /> </Chip>
                    </Typography>
            </React.Fragment>
          } secondary={ch.challenge.description} />
      </ListItem>
            ))}
    </List>
</TabPanel>
<TabPanel value={value} index={1}>
<List sx={{width: '100%', maxWidth: 800,position: 'relative', overflow: 'auto', maxHeight: 300,}}>
  {profile.studentWorkItems && profile.studentWorkItems.filter(studentWorkItem => studentWorkItem.type===1).map(gd =>(gd &&
      <ListItem>
        <ListItemAvatar>
          <Avatar>
            <ForumIcon />
          </Avatar>
        </ListItemAvatar>
        <ListItemText primary={
            <React.Fragment>
               <Typography variant="subtitle2" gutterBottom>
               {gd.event.name} <Chip icon={<StarsIcon/>} label={gd.points + " pts"} sx={{color : 'white', background: '#007991'}}  color="primary" size="small" ><StarsIcon fontSize="small" /> </Chip>
                    </Typography>
            </React.Fragment>
          } secondary={gd.event.description} />
      </ListItem>
            ))}
    </List>
  </TabPanel>

  <TabPanel value={value} index={2}>
 <List sx={{width: '100%', maxWidth: 800,position: 'relative', overflow: 'auto', maxHeight: 300,}}>
          {profile.studentWorkItems && profile.studentWorkItems.filter(studentWorkItem => studentWorkItem.type===5).map(blog =>(blog &&
            <ListItem>
              <ListItemAvatar>
                <Avatar>
                  <MenuBookIcon />
                </Avatar>
              </ListItemAvatar>
              <ListItemText primary={
                <React.Fragment>
                  <Typography variant="subtitle2" gutterBottom>
                      {blog.assetName} <Chip icon={<StarsIcon/>} label={blog.points + " pts"} sx={{color : 'white', background: '#007991'}} color="primary" size="small" ><StarsIcon fontSize="small" /> </Chip>
                  </Typography>
                </React.Fragment>
                } secondary={blog.assetDescription} />
            </ListItem>
            ))}
          </List>
</TabPanel>


<TabPanel value={value} index={3}>
 <List sx={{width: '100%', maxWidth: 800,position: 'relative', overflow: 'auto', maxHeight: 300,}}>
          {profile.studentWorkItems && profile.studentWorkItems.filter(studentWorkItem => studentWorkItem.type===6).map(vlog =>(
            <ListItem>
              <ListItemAvatar>
                <Avatar>
                  <YouTubeIcon  sx={{color : '#e62117',background: 'white'}}/>
                </Avatar>
              </ListItemAvatar>
              <ListItemText primary={
                <React.Fragment>
                  <Typography variant="subtitle2" gutterBottom>
                      {vlog.assetName} <Chip icon={<StarsIcon/>} label={vlog.points + " pts"} sx={{color : 'white', background: '#007991'}} color="primary" size="small" ><StarsIcon fontSize="small" /> </Chip>
                  </Typography>
                </React.Fragment>
          } secondary={vlog.assetDescription} />
            </ListItem>
            ))}
    </List>
</TabPanel>


    </Box>
          </Paper>
}
<Backdrop sx={{ color: '#fff', zIndex: (theme) => theme.zIndex.drawer + 1 }} open={isPending} onClick={handleClose}>
        <CircularProgress color="inherit" />
      </Backdrop>
</Container>
</>
);
}