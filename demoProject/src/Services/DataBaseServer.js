
import { Client } from 'pg';
const client = new Client({
  host: 'localhost',
  port: 5433,
  user: 'postgres',      
  password: 'centra', 
  database: 'BloodDonor'
});

  export default {
    query: async (text, params) => {    
        try {
            const res = await client.query(text, params);
            return res;
        } catch (err) {
            console.error('Query error:', err.stack);
            throw err; 
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


