var express = require('express');
var router = express.Router();
import userControllers from "../controller/User"
import verifyJWT from '../middleware/authenticator'

const userRoute = (app) => {
    router.post("/create-new-user", userControllers.createNewUser);
    return app.use("/", router)
}
module.exports = userRoute;