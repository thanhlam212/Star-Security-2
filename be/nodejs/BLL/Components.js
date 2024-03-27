import bcrypt from "bcrypt";
import authDAL from "../DAL/Auth";
const salt = bcrypt.genSaltSync(10);

const checkUserEmail = async (email) => {
  try {
    let user = await authDAL.findUserByEmail(email);
    if (user) {
      return user;
    } else {
      return null;
    }
  } catch (e) {
    console.log(e);
    throw e
  }
};

const hashUserPassword = (password) => {
  try {
    let hashPassword = bcrypt.hashSync(password, salt);
    return hashPassword
  } catch (e) {
    console.log(e);
  }
}

module.exports = {
  checkUserEmail,
  hashUserPassword,
};