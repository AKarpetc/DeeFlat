import moment from 'moment';
import { useEffect, useState } from 'react';
import {
  Avatar,
  Box,
  Button,
  Card,
  CardActions,
  CardContent,
  Divider,
  Typography
} from '@material-ui/core';
import authFetch from "../../utils/authFetch";
import {
  useReactOidc
} from '@axa-fr/react-oidc-context';

const AccountProfile = (props) => {

  const [user, setUser] = useState({
    avatar: '/static/images/avatars/avatar_6.png',
    city: 'Los Angeles',
    country: 'USA',
    jobTitle: 'Senior Developer',
    name: 'Katarina Smith',
    timezone: 'GTM-7'
  });

  let authRequest = authFetch();

  let {
    oidcUser
  } = useReactOidc();

  useEffect(() => {

    //Запрос на IdentityServer можно делать с куками
    fetch("/admin/api/User/GetCurentUserInfo").then((result) => {
      return result.json();
    }).then((model) => {
      console.log('result', model);
      setUser(model);
    });

    //Запрос на WebApi других серверов делают с токеном пока реализован тока get можно развивать по необходимости
    authRequest.get('/dicthttp/api/Skill/GetAuthorized').then(res => res.json()).then(x => console.log(x));

  }, []);
  return (
    <Card {...props}>
      <CardContent>
        <Box
          sx={{
            alignItems: 'center',
            display: 'flex',
            flexDirection: 'column'
          }}
        >
          <Avatar
            src={user.avatar}
            sx={{
              height: 100,
              width: 100
            }}
          />
          <Typography
            color="textPrimary"
            gutterBottom
            variant="h3"
          >
            {user.name + " " + user.surname}
          </Typography>
          <Typography
            color="textSecondary"
            variant="body1"
          >
            {"Email: " + `${user.email}`}
          </Typography>
        </Box>
      </CardContent>
      <Divider />
      <CardActions>
        <Button
          color="primary"
          fullWidth
          variant="text"
        >
          Upload picture
        </Button>
      </CardActions>
    </Card>
  )
};

export default AccountProfile;
