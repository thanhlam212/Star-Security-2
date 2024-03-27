'use strict';
const {
    Model
} = require('sequelize');
module.exports = (sequelize, DataTypes) => {
    // class offer extends Model {
    //     /**
    //      * Helper method for defining associations.
    //      * This method is not a part of Sequelize lifecycle.
    //      * The `models/index` file will call this method automatically.
    //      */
    //     static associate(models) {
    //         // define association here
    //         offer.hasOne(models.user_offer, { foreignKey: 'role_id' })
    //     }
    // }
    const offer = sequelize.define("offer", {
        Id: {
            type: DataTypes.CHAR,
            primaryKey: true,
            allowNull: false,
        },
        TotalPayment: {
            type: DataTypes.DECIMAL(65, 30),
            allowNull: false,
        },
        StartDate: {
            type: DataTypes.DATE,
            allowNull: false,
        },
        EndDate: {
            type: DataTypes.DATE,
            allowNull: false,
        },
        ProvideService: {
            type: DataTypes.TEXT('long'),
            allowNull: false,
        },
        EmployeeId: {
            type: DataTypes.CHAR,
            allowNull: false,
        },
        ClientId: {
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
        modelName: 'offer',
        tableName: 'offer',
    });
    offer.associate = (models) => {
        // define association here
        offer.belongsTo(models.client, { foreignKey: 'ClientId' })
        offer.belongsTo(models.employee, { foreignKey: 'EmployeeId' })
    }
    return offer;
};