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
  const [isEdit, setIsEdit] = useState(true);

  function chnageIsEdit() {
    alert();
    setIsEdit(!isEdit);

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
              <AccountProfile isEdit={chnageIsEdit} />

            </Grid>
            <Grid
              item
              lg={8}
              md={6}
              xs={12}
            >
              {isEdit === true ? <AccountProfileDetails /> : <div></div>}
            </Grid>
          </Grid>
        </Container>
      </Box>
    </>
  )
};

export default Account;
