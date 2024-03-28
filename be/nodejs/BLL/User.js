import bcrypt from "bcrypt";
import { hashUserPassword, checkUserEmail, checkUserById } from "./Components";
import userDAL from "../DAL/User"
import { includes } from "lodash";

const salt = bcrypt.genSaltSync(10);

const createNewUserBLL = async (data) => {
    try {
      let email = data.email;
      let phone = data.phone;
      let role = data.role;
      let password = data.password;
  
      if (!email || !password || !role || !phone) {
        return {
          message: "Missing required parameters",
          code: 2
        }
      }
      let isExist = await checkUserEmail(email);
      if (!isExist) {
        let hashPassword = hashUserPassword(password);
        data.password = hashPassword
        let response = await userDAL.createNewUserDAL(data)
        return {
          message: response.message,
          code: response.code
        }
      } else {
        return {
          message: "The email is already exist",
          code: 0
        }
      }
    } catch (e) {
      console.log(e);
      return {
        message: `Server error`,
        code: 0,
      };
    }
  };

  module.exports = {
    createNewUserBLL
  };