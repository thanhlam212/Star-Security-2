import { includes } from "lodash";
import db from "../models/index";
const { Op } = require("sequelize");
import { sequelize } from "../models/index";

const createNewUserDAL = async (data) => {
    try {
      const user = await db.users.create({
        email: data.email,
        name: data.name,
        phone: data.phone,
        role_id: data.role,
        gender: data.gender,
        address: data.address,
        birthday: data.birthday,
        start_working_time: data.start_working_time,
        end_working_time: data.end_working_time,
        grant: data.grant,
        manager: data.manager,
        hired_date: data.hired_date,
      });
      await db.accounts.create({
        user_id: user.id,
        password: data.password,
        status: "Active",
      });
      return {
        message: "Create new user successfully!",
        code: 1,
      };
    } catch (e) {
      console.log(e);
      throw {
        code: 500,
        message: `Server error`
      }
    }
  };

  module.exports = {
    createNewUserDAL
  };