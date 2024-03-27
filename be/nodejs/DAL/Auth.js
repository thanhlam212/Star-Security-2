import db from "../models/index";

const findUserByEmail = async (email) => {
  try {
    let user = await db.account.findOne({
      include: [{ model: db.employee, raw: true, }],
      where: { Email: email },
    });
    return user;
  } catch (e) {
    console.log(e);
    throw {
      code: 500,
      message: `Server error`
    }
  }
};

// const findUserAccountByEmail = async (email) => {
//   try {
//     let user = await db.users.findOne({
//       include: [{ model: db.accounts, raw: true, }],
//       where: { email: email },
//     });
//     return user;
//   } catch (e) {
//     console.log(e);
//     throw {
//       code: 500,
//       message: `Server error`
//     }
//   }
// };

const updateForgotPassword = async (email, token) => {
  try {
    await db.account.update({
      Token: token
    },
      { where: { Email: email } },
    );
  } catch (e) {
    console.log(e);
    throw {
      code: 500,
      message: `Server error`
    }
  }
}

const findAccountByToken = async (token) => {
  try {
    let account = await db.account.findOne({
      where: { Token: token },
    });
    return account;
  } catch (e) {
    console.log(e);
    throw {
      code: 500,
      message: `Server error`
    }
  }
};

const resetPassword = async (id, password) => {
  try {
    await db.account.update({
      PasswordHash: password,
      Token: null
    },
      { where: { Id: id } },
    );
  } catch (e) {
    console.log(e);
    throw {
      code: 500,
      message: `Server error`
    }
  }
}

module.exports = {
  findUserByEmail,
  // findUserAccountByEmail,
  updateForgotPassword,
  findAccountByToken,
  resetPassword,
};
