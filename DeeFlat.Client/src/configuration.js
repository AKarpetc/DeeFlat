const configuration = {
    client_id: 'spa.client',
    redirect_uri: 'http://localhost:3000/authentication/callback',
    response_type: 'code',
    post_logout_redirect_uri: 'http://localhost:3000/',
    scope: 'openid profile scope2 scope1',
    authority: 'https://localhost:5001/',
    silent_redirect_uri: 'http://localhost:3000/authentication/silent_callback',
    client_secret: ["511536EF-F270-4058-80CA-1C89C192F69A"],
    automaticSilentRenew: true,
    loadUserInfo: true,
  };
  
  export default configuration;