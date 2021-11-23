import { useState, useEffect } from 'react';
import {
  Box,
  Button,
  Card,
  CardContent,
  CardHeader,
  Divider,
  Grid,
  TextField
} from '@material-ui/core';
import authObj from "../../utils/authFetch";


const AccountProfileDetails = (props) => {
  const [values, setValues] = useState({
    name: 'Katarina',
    surname: 'Smith',
    email: 'demo@devias.io',
    phone: '',
    city: 'Alabama',
    countryName: 'USA'
  });

  const [countries, setCountries] = useState([]);
  const [cities, setCities] = useState([]);

  let loadCities = function (countruId) {
    fetch(`/dicthttp/api/Cities?countryId=${countruId}`, authObj.get).then((result) => {
      return result.json();
    }).then((model) => {
      setCities(model);
    });
  }

  useEffect(() => {
    fetch("/admin/api/User/GetCurentUserInfo").then((result) => {
      return result.json();
    }).then((model) => {
      setValues(model);

      loadCities(model.countryId);
    });

    console.log("authFetch", authObj);

    fetch("/dicthttp/api/Countries", authObj.get).then((result) => {
      return result.json();
    }).then((model) => {
      setCountries(model);
    });

  }, []);

  const handleChange = (event) => {
    if (event.target.name == "countryId") {
      console.log("customlog", event.target);
      loadCities(event.target.value);
    }

    setValues({
      ...values,
      [event.target.name]: event.target.value
    });
  };

  return (
    <form
      autoComplete="off"
      noValidate
    >
      <Card>
        <CardHeader
          subheader="The information can be edited"
          title="Profile"
        />
        <Divider />
        <CardContent>
          <Grid
            container
            spacing={3}
          >
            <Grid
              item
              md={6}
              xs={12}
            >
              <TextField
                fullWidth
                helperText="Please specify the first name"
                label="First name"
                name="name"
                onChange={handleChange}
                required
                value={values.name}
                variant="outlined"
              />
            </Grid>
            <Grid
              item
              md={6}
              xs={12}
            >
              <TextField
                fullWidth
                label="Last name"
                name="surname"
                onChange={handleChange}
                required
                value={values.surname}
                variant="outlined"
              />
            </Grid>
            <Grid
              item
              md={6}
              xs={12}
            >
              <TextField
                fullWidth
                label="Email Address"
                name="email"
                onChange={handleChange}
                required
                value={values.email}
                variant="outlined"
              />
            </Grid>
            <Grid
              item
              md={6}
              xs={12}
            >
              <TextField
                fullWidth
                label="Phone Number"
                name="phone"
                onChange={handleChange}
                type="number"
                value={values.phone}
                variant="outlined"
              />
            </Grid>
            <Grid
              item
              md={6}
              xs={12}
            >
              <TextField
                fullWidth
                label="Выберите страну: "
                name="countryId"
                onChange={handleChange}
                required
                select
                SelectProps={{ native: true }}
                value={values.countryId}
                variant="outlined"
              >
                {countries.map((option) => (
                  <option
                    key={option.id}
                    value={option.id}
                  >
                    {option.name}
                  </option>
                ))}
              </TextField>
            </Grid>
            <Grid
              item
              md={6}
              xs={12}
            >
              <TextField
                fullWidth
                label="Выберите город: "
                name="cityId"
                onChange={handleChange}
                required
                select
                SelectProps={{ native: true }}
                value={values.cityId}
                variant="outlined"
              >
                {cities.map((option) => (
                  <option
                    key={option.id}
                    value={option.id}
                  >
                    {option.name}
                  </option>
                ))}
              </TextField>
            </Grid>
          </Grid>
        </CardContent>
        <Divider />
        <Box
          sx={{
            display: 'flex',
            justifyContent: 'flex-end',
            p: 2
          }}
        >
          <Button
            color="primary"
            variant="contained"
            onClick={() => {  }}
          >
            Сохранить данные
          </Button>
        </Box>
      </Card>
    </form>
  );
};

export default AccountProfileDetails;
