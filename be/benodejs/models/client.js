'use strict';
const {
    Model
} = require('sequelize');
module.exports = (sequelize, DataTypes) => {
    // class client extends Model {
    //     /**
    //      * Helper method for defining associations.
    //      * This method is not a part of Sequelize lifecycle.
    //      * The `models/index` file will call this method automatically.
    //      */
    //     static associate(models) {
    //         // define association here
    //         client.hasOne(models.user_client, { foreignKey: 'role_id' })
    //     }
    // }
    const client = sequelize.define("client", {
        Id: {
            type: DataTypes.CHAR,
            primaryKey: true,
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
        modelName: 'client',
        tableName: 'client',
    });
    client.associate = (models) => {
        // define association here
        client.hasMany(models.offer, { foreignKey: 'ClientId' })
    }
    return client;
};