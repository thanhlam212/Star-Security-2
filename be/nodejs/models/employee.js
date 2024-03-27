'use strict';
const {
    Model
} = require('sequelize');
module.exports = (sequelize, DataTypes) => {
    // class employee extends Model {
    //     /**
    //      * Helper method for defining associations.
    //      * This method is not a part of Sequelize lifecycle.
    //      * The `models/index` file will call this method automatically.
    //      */
    //     static associate(models) {
    //         // define association here
    //         employee.hasOne(models.user_employee, { foreignKey: 'role_id' })
    //     }
    // }
    const employee = sequelize.define("employee", {
        Id: {
            type: DataTypes.CHAR,
            primaryKey: true,
            allowNull: false,
        },
        EmployeeCode: {
            type: DataTypes.STRING,
            allowNull: false,
            unique: true
        },
        EducationalQualification: {
            type: DataTypes.TEXT('long'),
            allowNull: false,
        },
        Role: {
            type: DataTypes.TEXT('long'),
            allowNull: false,
        },
        Grade: {
            type: DataTypes.TEXT('long'),
            allowNull: false,
        },
        Achievements: {
            type: DataTypes.TEXT('long'),
        },
        ProvideService: {
            type: DataTypes.TEXT('long'),
            allowNull: false,
        },
        BranchId: {
            type: DataTypes.CHAR,
            allowNull: false,
        },
        CurrentOfferId: {
            type: DataTypes.CHAR,
        },
        Name: {
            type: DataTypes.TEXT('long'),
            allowNull: false,
        },
        Gender: {
            type: DataTypes.TEXT('long'),
            allowNull: false,
        },
        Address: {
            type: DataTypes.TEXT('long'),
        },
        ContactNumber: {
            type: DataTypes.TEXT('long'),
        },
        DateOfBirth: {
            type: DataTypes.DATE,
            allowNull: false,
        },
        Email: {
            type: DataTypes.STRING,
            allowNull: false,
            unique: true
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
        modelName: 'employee',
        tableName: 'employee',
    });
    employee.associate = (models) => {
        // define association here
        employee.hasMany(models.account, { foreignKey: 'EmployeeId' })
        employee.belongsTo(models.branch, { foreignKey: 'BranchId' })
        employee.hasMany(models.offer, { foreignKey: 'EmployeeId' })
    }
    return employee;
};