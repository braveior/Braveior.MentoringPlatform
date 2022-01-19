import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';

import * as React from 'react';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogContentText from '@mui/material/DialogContentText';
import DialogTitle from '@mui/material/DialogTitle';

import { useState, useEffect } from 'react';

export default function SkillsTable ({userSkills, handleClose}) {
const [open, setOpen] = React.useState(false);

 const handleSubmit = () => {
    console.log(selectedUserSkill.stars);
    setOpen(false);
  };
 const handleDialogClose = () => {
    setOpen(false);
    handleClose();
  };

const [selectedUserSkill, setSelectedUserSkill] = useState({});

const onEdit = (userSkill) => {
  setSelectedUserSkill({skillName:userSkill.skill.name, stars:userSkill.stars});
  setOpen(true);
}

const handleSkillChange = (event) => {
      const name =event.target.name;
      const value =event.target.value;
      setSelectedUserSkill(values => ({...values, [name]:value}));  
  };




return (
<>

 <Table sx={{ minWidth: 650 }} size="small" aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell>Skill</TableCell>
            <TableCell>Rating</TableCell>
            <TableCell></TableCell>
            <TableCell></TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {userSkills && userSkills.map(userSkill => (
            <TableRow
              key={userSkill.userSkillId}
              sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
            >
              <TableCell component="th" scope="row">
                {userSkill.skill.name}
              </TableCell>
              <TableCell align="right">{userSkill.stars}</TableCell>
              <TableCell align="right"><Button variant="outlined" onClick={()=>onEdit(userSkill)}>Edit</Button></TableCell>
              <TableCell align="right"><Button variant="outlined">Delete</Button></TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>

 <Dialog open={open} onClose={handleClose}>
        <DialogTitle>Edit Skill</DialogTitle>
        <DialogContent>
         <TextField
          id="txtSkillName"
          label="SkillName"
          variant="outlined"
          name="skillName"
          onChange={handleSkillChange}
          value={(selectedUserSkill && selectedUserSkill.skillName) || ''}/>
         <TextField
          id="txtStars"
          label="Stars"
          name="stars"  
          variant="outlined"
          onChange={handleSkillChange}
          value={(selectedUserSkill && selectedUserSkill.stars) || ''}/>
        </DialogContent>
        <DialogActions>
          <Button onClick={handleDialogClose}>Cancel</Button>
          <Button onClick={handleSubmit}>Submit</Button>
        </DialogActions>
      </Dialog> 
</>
)
}