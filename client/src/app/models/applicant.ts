import {ApplicantResume} from './applicantResume'

export interface Applicant {
    applicantResume: ApplicantResume;
    userName: string;
    firstName: string;
    lastName: string;
    email: string;
    phoneNumber: string;
    city: string;
    country: string;
    gender: string;
    id: number;
    applicantHasDisability: boolean;
    applicantIsProtectedVeteran: boolean;
    applicantHasWorkAuthorization: boolean;
}