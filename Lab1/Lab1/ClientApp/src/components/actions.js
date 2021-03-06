﻿export const userPostFetch = user => {
    return dispatch => {
        return fetch("http://localhost:50854/api/users/login", {
                method: "GET",
                headers: {
                    'Content-Type': 'application/json',
                    Accept: 'application/json',
                },
                body: JSON.stringify({ user })
            })
            .then(resp => resp.json())
            .then(data => {
                if (data.message) {
                    //Тут прописываем логику
                } else {
                    localStorage.setItem("token", data.jwt)
                    dispatch(loginUser(data.user))
                }
            })
    }
}

const loginUser = userObj => ({
    type: 'LOGIN_USER',
    payload: userObj
})