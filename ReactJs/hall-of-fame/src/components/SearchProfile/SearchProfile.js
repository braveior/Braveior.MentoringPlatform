import Container from '@mui/material/Container';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import Grid from '@mui/material/Grid';
import Typography from '@mui/material/Typography';
import Divider from '@mui/material/Divider';
import Autocomplete from '@mui/material/Autocomplete';
import { useState, useEffect } from 'react';


import StudentDetails from "./StudentDetails";



export default function SearchProfile () {
  const [colleges, setColleges] = useState(null);
  const [students, setStudents] = useState([]);
  const [college, setCollege] = useState(null);
  const [student, setStudent] = useState(null);
  const [enableStudentSelection, setEnableStudentSelection]  = useState(false);

  const [studentProfile, setStudentProfile] = useState(null);




useEffect(() => {
   fetchColleges();
  }, []);


const fetchColleges = () => {

      fetch('https://student.braveior.com/api/Profile/getcolleges')
      .then(res => {
        if (!res.ok) { // error coming back from server
          throw Error('could not fetch the data for that resource');
        } 
        return res.json();
      })
      .then(data => {
        setColleges(data);
      })
      .catch(err => {
          // auto catches network / connection error
         // setError('API call Error !!');
      })

}

const fetchStudents = (studentKey) => {

      fetch('https://student.braveior.com/api/Profile/getstudents/1/' + studentKey
       ,{
        headers: {
            'Authorization': `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6InNyZWVAZW1haWwuY29tIiwicm9sZSI6IjIiLCJuYmYiOjE2NDIxMzY4ODksImV4cCI6MTcwNTIwODg4OSwiaWF0IjoxNjQyMTM2ODg5fQ.7qcT62Oix92ej3xRwhMLIz0FlWWnx1zbLma0--Q2pH4`
        }
    } )
      .then(res => {
        if (!res.ok) { // error coming back from server
          throw Error('could not fetch the data for that resource');
        } 
        return res.json();
      })
      .then(data => {
        setStudents(data);
      })
      .catch(err => {
          // auto catches network / connection error
         // setError('API call Error !!');
      })

}

const loadProfile = () => {
fetch('https://student.braveior.com/api/Profile/getprofile/1'
       ,{
        headers: {
            'Authorization': `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6InNyZWVAZW1haWwuY29tIiwicm9sZSI6IjIiLCJuYmYiOjE2NDIxMzY4ODksImV4cCI6MTcwNTIwODg4OSwiaWF0IjoxNjQyMTM2ODg5fQ.7qcT62Oix92ej3xRwhMLIz0FlWWnx1zbLma0--Q2pH4`
        }
    } )
      .then(res => {
        if (!res.ok) { // error coming back from server
          throw Error('could not fetch the data for that resource');
        } 
        return res.json();
      })
      .then(data => {
        setStudentProfile(data);
          console.log(studentProfile);
      })
      .catch(err => {
          // auto catches network / connection error
         // setError('API call Error !!');
      })


}

const handleDialogClose = () =>{
loadProfile();
}





  return (
<>
  {colleges && <Autocomplete
        id="CollegeList"
        freeSolo
        options={colleges.map((option) => option.name)}
        onChange={(event, newValue) => {
          setCollege(newValue);
        }}    
        renderInput={(params) => <TextField {...params} label="Search College"  variant="outlined" />}
      />}

 {(colleges && students) &&<Autocomplete
        disabled={college === null} 
        id="CollegeList"
        freeSolo
        options={students.map((option) => option.firstName + " " + option.lastName)}
        onInputChange={(event, newInputValue) => {
            if(newInputValue.length > 1)
            {
                fetchStudents(newInputValue);
            }
        }}
        onChange={(event, newValue) => {
          setStudent(newValue);

        }}    
        renderInput={(params) => <TextField {...params} label="Search Student"  variant="outlined" />}
      />}
    <Button disabled={student === null}  variant="contained" onClick={loadProfile}>Load Student Profile</Button>
 

<TextField
          id="lblFirstName"
          label="FirstName"
          variant="outlined"
          value={(studentProfile && studentProfile.studentName) || ''}
        />
<TextField
          id="lblLastName"
          label="LastName"
          variant="outlined"
          value={(studentProfile && studentProfile.studentName) || ''}
        />
<TextField
          id="txtAboutMyself"
          label="About Myself"
          multiline
          rows={6}
          value={(studentProfile && studentProfile.description) || ''}
        />
<TextField
          id="txtLinkedIn"
          label="linkedIn"
          variant="outlined"
          value={(studentProfile && studentProfile.linkedInLink) || ''}
        />
<TextField
          id="txtEmail"
          label="Email"
          variant="outlined"
          value={(studentProfile && studentProfile.email) || ''}
        />
 {studentProfile && <StudentDetails studentProfile = {studentProfile} handleDialogClose = {()=>handleDialogClose()}  ></StudentDetails>}
</>
  );

}