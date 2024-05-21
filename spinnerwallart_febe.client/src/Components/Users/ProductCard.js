import React from 'react';
import '../../StyleSheets/ProductDisplay.css';


export default function ProductCard({ productData }) {
    console.log(productData)
   
    return (

        <div className="product-card-container">
            <div className="product-card">
                <img src={`https://localhost:7090/Models/Photos/${productData.ImageUrl}`} alt="" className="product-img" /> 
                <div className="product-card-body">
                    <h5 className="product-title">{productData.ProductName}</h5>
                    <p className="product-text">
                        <button type="radio" className="user-radio">Small Size: {productData.Size1} Price: {productData.Price1}</button>
                        <button type="radio" className="user-radio">Small Size: {productData.Size2} Price: {productData.Price2}</button>
                        <button type="radio" className="user-radio">Small Size: {productData.Size3} Price: {productData.Price3}</button>
                        <input type="number" id="tentacles" name="tentacles" min="10" max="100" placeholder="Quantity"/>
                    </p>

                </div>
            </div>

        </div>

    )
}