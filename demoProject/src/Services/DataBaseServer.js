
import { Client } from 'pg';
const client = new Client({
  host: 'localhost',
  port: 5433,
  user: 'postgres',       // replace with your PostgreSQL username
  password: 'centra', // replace with your PostgreSQL password
  database: 'BloodDonor' // replace with your database name
});

  export default {
    query: async (text, params) => {    
        try {
            const res = await client.query(text, params);
            return res;
        } catch (err) {
            console.error('Query error:', err.stack);
            throw err; // Re-throw the error for handling in the calling function
        }
        },
    end: async () => {
        try {
            await client.end();
            console.log('PostgreSQL connection closed.');
        } catch (err) {
            console.error('Error closing connection:', err.stack);
        }
    }   
    };


