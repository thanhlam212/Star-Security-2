'use strict';
const {
    Model
} = require('sequelize');
module.exports = (sequelize, DataTypes) => {
    const branch = sequelize.define("branch", {
        Id: {
            type: DataTypes.CHAR,
            primaryKey: true,
            allowNull: false,
        },
        Name: {
            type: DataTypes.TEXT('long'),
            allowNull: false,
        },
        Region: {
            type: DataTypes.TEXT('long'),
            allowNull: false,
        },
        ContactDetail: {
            type: DataTypes.TEXT('long'),
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
        modelName: 'branch',
        tableName: 'branch',
    });
    branch.associate = (models) => {
        branch.hasMany(models.employee, { foreignKey: 'BranchId' })
    }
    return branch;
};