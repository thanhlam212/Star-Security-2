'use strict';
const {
    Model
} = require('sequelize');
module.exports = (sequelize, DataTypes) => {
    // class account extends Model {
    //     /**
    //      * Helper method for defining associations.
    //      * This method is not a part of Sequelize lifecycle.
    //      * The `models/index` file will call this method automatically.
    //      */
    //     static associate(models) {
    //         // define association here
    //         account.belongsTo(models.users, { foreignKey: 'user_id' })
    //     }
    // }
    const account = sequelize.define("account", {
        Id: {
            type: DataTypes.CHAR,
            primaryKey: true,
            allowNull: false,
        },
        Email: {
            type: DataTypes.STRING,
            allowNull: false,
            unique: true
        },
        PasswordHash: {
            type: DataTypes.TEXT('long'),
            allowNull: false,
        },
        Token: {
            type: DataTypes.STRING
        },
        EmployeeId: {
            type: DataTypes.CHAR,
            allowNull: false,
        },
        CreateDate: {
            type: DataTypes.DATE,
            allowNull: false,
        },
        DeleteDate: {
            type: DataTypes.DATE
        },
        UpdatedDate: {
            type: DataTypes.DATE
        }
    }, {
        sequelize,
        timestamps: false,
        modelName: 'account',
        tableName: 'account',
    });
    account.associate = (models) => {
        // define association here
        account.belongsTo(models.employee, { foreignKey: 'EmployeeId' })
    }
    return account;
};