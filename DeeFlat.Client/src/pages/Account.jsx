import { Helmet } from 'react-helmet';
import { useEffect, useState } from 'react';
import {
  Box,
  Container,
  Grid
} from '@material-ui/core';
import AccountProfile from '../components/account/AccountProfile';
import AccountProfileDetails from '../components/account/AccountProfileDetails';

const Account = () => {

  const [user, setUser] = useState({
    avatar: '/static/images/avatars/avatar_6.png',
    city: 'Los Angeles',
    country: 'USA',
    jobTitle: 'Senior Developer',
    name: 'Katarina Smith',
    timezone: 'GTM-7'
  });

  let firstReques = true;
  useEffect(() => {

    if (firstReques == true) {
      fetch("/admin/api/User/GetCurentUserInfo").then((result) => {
        return result.json();
      }).then((model) => {
        console.log('result', model);
        setUser(model);
      });
      firstReques = false;
    }

    //Запрос на WebApi других серверов делают с токеном пока реализован тока get можно развивать по необходимости
    // authRequest.get('/dicthttp/api/Skill/GetAuthorized').then(res => res.json()).then(x => console.log(x));

  }, []);


  const [isedit, setIsedit] = useState(true);

  function chnageIsEdit() {
    setIsedit(!isedit);
  }

  return (
    <>
      <Helmet>
        <title>Account | Material Kit</title>
      </Helmet>
      <Box
        sx={{
          backgroundColor: 'background.default',
          minHeight: '100%',
          py: 3
        }}
      >
        <Container maxWidth="lg">
          <Grid
            container
            spacing={3}
          >
            <Grid
              item
              lg={4}
              md={6}
              xs={12}
            >
              <AccountProfile chnageIsEdit={chnageIsEdit} isedit={isedit} user={user} />

            </Grid>
            <Grid
              item
              lg={8}
              md={6}
              xs={12}
            >
              {isedit === true ? <AccountProfileDetails /> : <div></div>}
            </Grid>
          </Grid>
        </Container>
      </Box>
    </>
  )
};

export default Account;
