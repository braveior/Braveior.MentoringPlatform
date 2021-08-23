import React from 'react';
import PropTypes from 'prop-types';
import { makeStyles } from '@material-ui/core/styles';
import Grid from '@material-ui/core/Grid';
import Paper from '@material-ui/core/Paper';
import Avatar from '@material-ui/core/Avatar';
import Container from '@material-ui/core/Container';
import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';
import Chip from '@material-ui/core/Chip';
import StarsIcon from '@material-ui/icons/Stars';
import Rating from '@material-ui/lab/Rating';
import Box from '@material-ui/core/Box';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemText from '@material-ui/core/ListItemText';
import ListItemAvatar from '@material-ui/core/ListItemAvatar';
import ImageIcon from '@material-ui/icons/Image';
import WorkIcon from '@material-ui/icons/Work';
import MenuBookIcon from '@material-ui/icons/MenuBook';
import YouTubeIcon from '@material-ui/icons/YouTube';
import ForumIcon from '@material-ui/icons/Forum';
import HomeIcon from '@material-ui/icons/Home';
import { Link, useLocation } from 'react-router-dom'
import { useState, useEffect } from 'react'
import useFetch from "../useFetch";
import Backdrop from '@material-ui/core/Backdrop';
import CircularProgress from '@material-ui/core/CircularProgress';
import LinkedInIcon from '@material-ui/icons/LinkedIn';
import EmojiObjectsIcon from '@material-ui/icons/EmojiObjects';
import Divider from '@material-ui/core/Divider';
import Tabs from '@material-ui/core/Tabs';
import Tab from '@material-ui/core/Tab';

function TabPanel(props) {
  const { children, value, index, ...other } = props;

  return (
    <div
      role="tabpanel"
      hidden={value !== index}
      id={`scrollable-auto-tabpanel-${index}`}
      aria-labelledby={`scrollable-auto-tab-${index}`}
      {...other}
    >
      {value === index && (
        <Box p={3}>
          <Typography>{children}</Typography>
        </Box>
      )}
    </div>
  );
}

TabPanel.propTypes = {
  children: PropTypes.node,
  index: PropTypes.any.isRequired,
  value: PropTypes.any.isRequired,
};

function a11yProps(index) {
  return {
    id: `scrollable-auto-tab-${index}`,
    'aria-controls': `scrollable-auto-tabpanel-${index}`,
  };
}


const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
  },
  image: {
    width: 128,
    height: 128,
  },
  img: {
    margin: 'auto',
    display: 'block',
    maxWidth: '100%',
    maxHeight: '100%',
  },
  large: {
    width: theme.spacing(10),
    height: theme.spacing(10),
  },
  medium: {
    width: theme.spacing(7),
    height: theme.spacing(7),
    backgroundColor: 'white'
  },
  bloglist: {
    width: '100%',
    maxWidth: 800,
    backgroundColor: theme.palette.background.paper,
    position: 'relative',
    overflow: 'auto',
    maxHeight: 300,
  },
skilllist: {
    maxWidth:500,
    backgroundColor: theme.palette.background.paper,
    position: 'relative',
    overflowY: 'scroll',
    overflowX: 'hidden',
    maxHeight: 150,
  },
  aboutmyself: {
    width: '100%',
    maxWidth: 800,
    
  },
  chipColor: {
    color : 'white',
    background: '#007991',
  },
  linkedinColor: {
    color : '#0e76a8',
    background: 'white',
  },
  leadColor: {
    color: 'white',
    background: 'black',
  },
youtubeColor: {
    color : '#e62117',
    background: 'white',
  }
}));
function useQuery() {
  return new URLSearchParams(useLocation().search);
}

export default function Detail() {
  let query = useQuery();
const [value, setValue] = React.useState(0);
  const { error, isPending, data: profile } = useFetch('http://7090-48476.el-alt.com/api/profile/getprofile/' + query.get('userId')) 
  const classes = useStyles();
  const preventDefault = (event) => event.preventDefault();
  const [open, setOpen] = React.useState(false);
  const handleClose = () => {
    setOpen(false);
  };
const handleChange = (event, newValue) => {
    setValue(newValue);
  };
  return (
    
    <Container maxWidth="lg">
      <Box p={1}><Link to="/"><Button variant="outlined">Back</Button></Link></Box>
      { error && <div>{ error }</div> }
      { profile && 
        <Paper elevation={1} >
        <Box p={4}>
<Grid container spacing={3}>
<Grid item xs={1} >
  <Avatar src={"/static/images/avatar/" + profile.userId + ".jpg"} className={classes.large} />
  
</Grid>
<Grid item xs={11} container direction="column">
              <Typography gutterBottom variant="h5">
                {profile.studentName} 
              <a href={profile.linkedInLink} target="_blank"><LinkedInIcon className={classes.linkedinColor} fontSize="large"/></a>
          
          <Chip icon={<StarsIcon/>} label={profile.points + " pts"} className={classes.chipColor}  color="primary" size="small" > </Chip>
              </Typography>
              <Typography variant="subtitle1" gutterBottom>
                      {profile.insitutionName}
              </Typography>
              <Typography variant="subtitle2" gutterBottom>
                {profile.isLeader == true && <Chip label={"Leader"} className={classes.leadColor} color="primary" size="small" ></Chip>}            
              </Typography>
</Grid>
              


</Grid>
              
              
          <Typography variant="h6" gutterBottom>
              About myself
          </Typography>
          <Typography variant="body2" gutterBottom className={classes.aboutmyself}>
          {profile.description}
          </Typography>
          <Grid item >
            <Typography  variant="h6">Technology Confidence Meter</Typography>
          <Box className={classes.skilllist}>
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
<Tab label="Hackathon" {...a11yProps(2)}>
</Tab>
<Tab label="R & D Solutioning" {...a11yProps(3)}>
</Tab>
<Tab label="Blogs" {...a11yProps(4)}>
</Tab>
<Tab label="Vlogs" {...a11yProps(5)}>
</Tab>
</Tabs>

<TabPanel value={value} index={0}>
<List className={classes.bloglist}>
            {profile.studentWorkItems && profile.studentWorkItems.filter(studentWorkItem => studentWorkItem.type===4).map(ch =>(ch &&
      <ListItem>
        <ListItemAvatar>
          <a href={ch.assetUrl} target="_blank"><Avatar className={classes.medium} >
          <YouTubeIcon className={classes.youtubeColor}  fontSize="large"/>
          </Avatar></a>
        </ListItemAvatar>
        <ListItemText primary={
            <React.Fragment>
               <Typography variant="subtitle2" gutterBottom>
                 <a href={ch.assetUrl} target="_blank">{ch.challenge.name}</a> <Chip icon={<StarsIcon/>} label={ch.points + " pts"} className={classes.chipColor}  color="primary" size="small" ><StarsIcon fontSize="small" /> </Chip>
                    </Typography>
            </React.Fragment>
          } secondary={ch.challenge.description} />
      </ListItem>
            ))}
    </List>
</TabPanel>
<TabPanel value={value} index={1}>
<List className={classes.bloglist}>
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
               {gd.event.name} <Chip icon={<StarsIcon/>} label={gd.points + " pts"} className={classes.chipColor}  color="primary" size="small" ><StarsIcon fontSize="small" /> </Chip>
                    </Typography>
            </React.Fragment>
          } secondary={gd.event.description} />
      </ListItem>
            ))}
    </List>
  </TabPanel>

 <TabPanel value={value} index={2}>

<List className={classes.bloglist}>
            {profile.studentWorkItems && profile.studentWorkItems.filter(studentWorkItem => studentWorkItem.type===2).map(h =>(h &&
      <ListItem>
        <ListItemAvatar>
          <Avatar>
            <ForumIcon />
          </Avatar>
        </ListItemAvatar>
        <ListItemText primary={
            <React.Fragment>
               <Typography variant="subtitle2" gutterBottom>
               {h.event.name} <Chip icon={<StarsIcon/>} label={h.points + " pts"} className={classes.chipColor} color="primary" size="small" ><StarsIcon fontSize="small" /> </Chip>
                    </Typography>
            </React.Fragment>
          } secondary={h.event.description} />
      </ListItem>
            ))}
    </List>

</TabPanel>

 <TabPanel value={value} index={3}>
<List className={classes.bloglist}>
            {profile.studentWorkItems && profile.studentWorkItems.filter(studentWorkItem => studentWorkItem.type===3).map(rd =>(rd.event &&
      <ListItem>
        <ListItemAvatar>
          <Avatar>
          <EmojiObjectsIcon/>
          </Avatar>
        </ListItemAvatar>
        <ListItemText primary={
            <React.Fragment>
               <Typography variant="subtitle2" gutterBottom>
               {rd.event.name} <Chip icon={<StarsIcon/>} label={rd.points + " pts"} className={classes.chipColor} color="primary" size="small" ><StarsIcon fontSize="small" /> </Chip>
                    </Typography>
            </React.Fragment>
          } secondary={rd.event.description} />
      </ListItem>
            ))}
    </List>
</TabPanel>
 

 <TabPanel value={value} index={4}>
 <List className={classes.bloglist}>
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
                      {blog.assetName} <Chip icon={<StarsIcon/>} label={blog.points + " pts"} className={classes.chipColor} color="primary" size="small" ><StarsIcon fontSize="small" /> </Chip>
                  </Typography>
                </React.Fragment>
                } secondary={blog.assetDescription} />
            </ListItem>
            ))}
          </List>
</TabPanel>


<TabPanel value={value} index={5}>
 <List className={classes.bloglist}>
          {profile.studentWorkItems && profile.studentWorkItems.filter(studentWorkItem => studentWorkItem.type===6).map(vlog =>(
            <ListItem>
              <ListItemAvatar>
                <Avatar>
                  <YouTubeIcon  className={classes.youtubeColor}/>
                </Avatar>
              </ListItemAvatar>
              <ListItemText primary={
                <React.Fragment>
                  <Typography variant="subtitle2" gutterBottom>
                      {vlog.assetName} <Chip icon={<StarsIcon/>} label={vlog.points + " pts"} className={classes.chipColor} color="primary" size="small" ><StarsIcon fontSize="small" /> </Chip>
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
<Backdrop className={classes.backdrop} open={isPending} onClick={handleClose}>
        <CircularProgress color="inherit" />
      </Backdrop>
</Container>
    )
  }
  