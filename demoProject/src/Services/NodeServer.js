// index.js
import  databaseserver from './DataBaseServer.js';

export default {
   methods: {
    async fetchData() {
        try {
            const res = await databaseserver.query('SELECT * FROM "DonoteBlood";');
            console.log('Query results:', res.rows);
            return res.rows; // Return the rows for further processing if needed
        } catch (err) {
            console.error('Query error:', err.stack);
            throw err; // Re-throw the error for handling in the calling function
        }
        }
    },
};

