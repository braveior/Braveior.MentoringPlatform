import Tabs from '@mui/material/Tabs';
import Tab from '@mui/material/Tab';
import Box from '@mui/material/Box';
import PropTypes from 'prop-types';
import React from 'react';

import SkillsTable from "./SkillsTable";

export default function StudentDetails ({studentProfile,handleDialogClose}) {
  const [tabValue, setTabValue] = React.useState(0);


  const handleTabChange = (event, newValue) => {
    setTabValue(newValue);
  };  


const handleClose = () =>{
console.log("Dialog Closed");
handleDialogClose();
}

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

return (
<>
<Box sx={{ width: '100%' }}>
      <Box sx={{ borderBottom: 1, borderColor: 'divider' }}>
        <Tabs value={tabValue} onChange={handleTabChange} aria-label="basic tabs example">
          <Tab label="SKILLS" {...a11yProps(0)} />
          <Tab label="EVENTS" {...a11yProps(1)} />
          <Tab label="CHALLENGES" {...a11yProps(2)} />
          <Tab label="BLOGS/VLOGS" {...a11yProps(3)} />
        </Tabs>
      </Box>
      <TabPanel value={tabValue} index={0}>
        


     {studentProfile &&<SkillsTable userSkills = {studentProfile.userSkills} handleClose = {()=> handleClose() }></SkillsTable>}




      </TabPanel>
      <TabPanel value={tabValue} index={1}>
        Item Two
      </TabPanel>
      <TabPanel value={tabValue} index={2}>
        Item Three
      </TabPanel>
    <TabPanel value={tabValue} index={3}>
        Item Four
      </TabPanel>
    </Box>
</>
)
}