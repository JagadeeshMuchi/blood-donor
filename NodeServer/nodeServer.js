const express = require('express');
const cors = require('cors');

const app = express();
app.use(express.urlencoded({ extended: true }));
app.use(express.json());

app.use(cors({
  origin: 'http://localhost:5173',
  methods: ['GET', 'POST', 'PUT', 'DELETE'],
  credentials: true
}));
const PORT = 3000;

const { Pool } = require('pg');
const pool = new Pool({
  host: 'localhost',
  database: 'BloodDonor',
  user: 'postgres',
  password: 'centra',
  port: 5433
});

// Test PostgreSQL connection
pool.connect((err, client, release) => {
  if (err) {
    return console.error('Error acquiring client', err.stack);
  }
  client.query(`SELECT * FROM "DonoteBlood" where "sName" ILIKE $1`, [`%${'har'}%`], (err, result) => {
    release();
    if (err) {
      return console.error('Error executing query', err.stack);
    }
    console.log('PostgreSQL connected:', result.rows);
  });
});


// Endpoint to get blood donor list filtered by sName
app.get('/blooddonor',async  (req, res) => {
  try {
    const sName = req.query.sDonorName || '';
    const result = await pool.query(`SELECT * FROM "DonoteBlood" where "sName" ILIKE $1`, [`%${sName}%`]);
    res.send(result.rows);
  } catch (err) {
    console.error('Error fetching blood donors:', err);
    res.status(500).json({ error: 'Database error' });
  }
});

app.get('/checkLogin', async (req, res) => {
  const username = req.query.username;
  const password = req.query.password;
  try {
    const sqry = 'SELECT * FROM "Login" WHERE ("UserName" ilike $1 OR "UserMail" ilike $1) AND "PassWord" = $2';
    const result = await pool.query(sqry, [username, password]);
    if (result.rows && result.rows.length > 0) {
      res.send(result.rows[0]);
    } else {
      res.send({ success: false, message: 'Invalid credentials' });
    }
  } catch (err) {
    console.error('Error during login:', err);
    res.status(500).json({ success: false, message: 'Database error' });
  }
});
app.get('/getPorfile',async(req,res)=>{
  const id=req.query.id;
  const checkDonoteId= await pool.query(`select "UserId" from "DonoteBlood" where "UserId"=$1`,[id]);
  if(checkDonoteId.rows.length>0 && checkDonoteId.rows[0].UserId>0){
 const result= await pool.query(`select d.*,l."UserMail",l."Country" from "DonoteBlood" d inner join "Login" l 
on l."UserId"=d."UserId" where l."UserId"= $1`,[id]);
    
  res.send(result.rows[0])
  }else{
     const result1= await pool.query('select "UserName" "sName","UserMail","Country" from "Login" where "UserId"=$1',[id])
     res.send(result1.rows[0])
  }
  
})

app.post('/createAccount',async(req,res)=>{
  console.log(req);
  try {
    const {
      username,
      email,
      password,
      country,
      // sName,
      // BloodGroup,
      // Age,
      // Gender
    } = req.body;

   
    const loginInsert = `INSERT INTO "Login" ("UserName", "UserMail", "PassWord", "Country") VALUES ($1, $2, $3, $4) RETURNING "UserId"`;
    const loginResult = await pool.query(loginInsert, [username, email, password, country]);
    const userId = loginResult.rows[0].UserId;
  res.send(userId)
    //res.json({ success: true, user: donorResult.rows[0] });
  } catch (err) {
    console.error('Error creating account:', err);
    res.status(500).json({ success: false, message: 'Database error' });
  }
});
app.post('/BloodDonorPost',async(req,res)=>{
  try{
  console.log(req.body)
  const {sName,iPayFrequncy,iBloodGroup,iLocation,iDOB,UserId} =req.body;
  const donorInsert=`insert into "DonoteBlood"("sName","iDOB","iLocation","iPayFrequency","iBloodGroup","UserId") Values ($1,$2,$3,$4,$5,$6) RETURNING "iDonateId"`;
  const donorResult=await pool.query(donorInsert,[sName,iDOB,iLocation,iPayFrequncy,iBloodGroup,UserId])
  console.log(donorResult.rows[0].iDonateId)
  const iDonateId=donorResult.rows[0].iDonateId;
  res.send(iDonateId)
}  catch (err) {
    console.error('Error creating account:', err);
    res.status(500).json({ success: false, message: 'Database error' });
  }
});
app.get('/', (req, res) => {
  res.send('Hello from Express backend!');
});

app.listen(PORT, () => {
  console.log(`Server is running on http://localhost:${PORT}`);
});
