import React from "react";
import Header from "./Header";
import Login from "./components/Login";
import HallOfFame from "./components/HallOfFame";
import Profile from "./components/Profile";
import SearchProfile from "./components/SearchProfile/SearchProfile";
import { Routes,Route} from 'react-router-dom'

export const AuthContext = React.createContext();

const initialState = {
  isAuthenticated: false,
  firstName: null,
  lastName: null,
  userRole: null,
  accessToken: null,
};

const reducer = (state, action) => {
  switch (action.type) {
    case "LOGIN":
      //localStorage.setItem("token", JSON.stringify(action.payload.token));
      return {
        ...state,
        isAuthenticated: true,
        firstName: action.payload.firstName,
        lastName: action.payload.lastName,
        userRole: action.payload.role,
        accessToken: action.payload.accessToken
      };
    case "LOGOUT":
      localStorage.clear();
      return {
        ...state,
        isAuthenticated: false,
        user: null
      };
    default:
      return state;
  }
};

function App() {
 const [state, dispatch] = React.useReducer(reducer, initialState);
  return (
<AuthContext.Provider
      value={{
        state,
        dispatch
      }}
    >
<Header/>
{state.isAuthenticated && "Login Succcessful"}
<Routes>
<Route path='/login' element={<Login/>} />
<Route path='/profile' element={<Profile/>} />
<Route path='/halloffame' element={<HallOfFame/>} />
{state.isAuthenticated &&<Route path='/searchprofile' element={<SearchProfile/>} />}
<Route path='/' element={<Login/>} />
</Routes>

</AuthContext.Provider>

  );
}

export default App;
