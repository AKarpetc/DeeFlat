import {
    useReactOidc
} from '@axa-fr/react-oidc-context';


let authObj = function () {
    let {
        oidcUser
    } = useReactOidc();
    let token = oidcUser.id_token;


    let getObj = {
        headers: {
            "Authorization": `Bearer ${token}`
        }
    };


    return {
        get: getObj
    }
}



export default authObj;
