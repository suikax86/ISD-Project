import { Outlet, Navigate } from 'react-router-dom'

const PrivateRoutes = () => {
    const roleLog = localStorage.getItem('role');
    let auth = {'role': roleLog}
    return(
        auth.role==="Admin" ? <Outlet/> : <Navigate to="/403"/>
    )
}

export default PrivateRoutes