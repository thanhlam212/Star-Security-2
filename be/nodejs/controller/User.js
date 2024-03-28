import userBLLs from "../BLL/User";

const createNewUser = async (req, res) => {
  let response = await userBLLs.createNewUserBLL(req.body);
  if (response.code === 0) {
    return res.status(403).send(response.message)
  }
  if (response.code === 1) {
    return res.status(200).send(response.message)
  }
  if (response.code === 2) {
    return res.status(422).send(response.message)
  }
};
