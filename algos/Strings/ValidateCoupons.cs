using System;

namespace algos.Strings
{
    public class ValidateCoupons
    {
        
    public bool isValidCoupon(string coupon){
        return isValidCoupon(coupon, 0, coupon.Length - 1);
    }

    public bool isValidCoupon(string coupon, int start, int end){
        if(coupon.Length == 0){
            return true;
        }

        if(coupon.Length % 2 == 1){
            return false;
        }


        var remaining = end - start + 1;
        if(remaining < 2){
            return false;
        }

        if(remaining == 2){
            return coupon[start] == coupon[end];
        }

        var result = false;

        if(coupon[start] == coupon[end]){

            result = isValidCoupon(coupon, start + 1, end - 1);

        }

        var mid = (start + end) / 2; 
        var result2 = isValidCoupon(coupon, start, mid) 
                      &&
                      isValidCoupon(coupon, mid + 1, end);

        return result || result2;
    }
    }
}
