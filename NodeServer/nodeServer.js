const express = require('express');
const cors = require('cors');
const app = express();

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
  client.query(`SELECT * FROM "DonoteBlood" where "sName" ILIKE $1`, [`%${'ha'}%`], (err, result) => {
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


app.get('/', (req, res) => {
  res.send('Hello from Express backend!');
});

app.listen(PORT, () => {
  console.log(`Server is running on http://localhost:${PORT}`);
});
