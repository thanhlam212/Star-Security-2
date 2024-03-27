import jwt from 'jsonwebtoken'
require('dotenv').config();
import authDAL from "../DAL/Auth";

const verifyJWT = async (req, res, next) => {
    // let authHeader = req.headers.authorization || req.headers.Authorization

    // if (!authHeader?.startsWith('Bearer ')) {
    //     return res.status(401).send('Unauthorized')
    // }
    // let token = authHeader.split(' ')[1]
    let token = req.cookies.jwt;
    if (token) {
        try {
            const decoded = jwt.verify(token, process.env.ACCESS_TOKEN_SECRET);
            req.user = await authDAL.findUserByEmail(decoded.username);
            next();
        } catch (error) {
            res.status(401);
            throw new Error("Not authorized, token failed");
        }
    } else {
        res.status(401);
        throw new Error("Not authorized, no token");
    }
}

module.exports = verifyJWT