import {
    useReactOidc
} from '@axa-fr/react-oidc-context';


let authFetch = function (url) {
    let {
        oidcUser
    } = useReactOidc();
    let token = oidcUser.id_token;


    var get = (url) => fetch(url, {
        headers: {
            "Authorization": `Bearer ${token}`
        }
    });


    return {
        get
    }
}



export default authFetch;
