package com.example.yp.Models;

public class Employees {

    private int idEmployee;
    private String surname;
    private String name;
    private String patronymic;
    private String login;
    private String password;
    private String passportData;
    private int postId;
    private int medicalBookId;
    private int concatId;
    private int statusEmployeeId;

    public Employees(String login, String password) {
        this.login = login;
        this.password = password;
    }

    public int getIdEmployee() {
        return idEmployee;
    }

    public void setIdEmployee(int idEmployee) {
        this.idEmployee = idEmployee;
    }

    public String getSurname() {
        return surname;
    }

    public void setSurname(String surname) {
        this.surname = surname;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getPatronymic() {
        return patronymic;
    }

    public void setPatronymic(String patronymic) {
        this.patronymic = patronymic;
    }

    public String getLogin() {
        return login;
    }

    public void setLogin(String login) {
        this.login = login;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public String getPassportData() {
        return passportData;
    }

    public void setPassportData(String passportData) {
        this.passportData = passportData;
    }

    public int getPostId() {
        return postId;
    }

    public void setPostId(int postId) {
        this.postId = postId;
    }

    public int getMedicalBookId() {
        return medicalBookId;
    }

    public void setMedicalBookId(int medicalBookId) {
        this.medicalBookId = medicalBookId;
    }

    public int getConcatId() {
        return concatId;
    }

    public void setConcatId(int concatId) {
        this.concatId = concatId;
    }

    public int getStatusEmployeeId() {
        return statusEmployeeId;
    }

    public void setStatusEmployeeId(int statusEmployeeId) {
        this.statusEmployeeId = statusEmployeeId;
    }
}
