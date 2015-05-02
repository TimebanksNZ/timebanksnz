Tables:
category: predefined categories for member skills and offers/needs
contact_method: lookup table for preferred contact methods: phone my mobile, text my mobile, phone me at home, email me, phone me at work.
country: lookup table for countries with geo location.
member: a time bank member.  Skills can be predefined categories (using member_skill table) or tags (using tag table)
member_permission: Associates a member with a permission (admin or super admin)
member_skill: Associates a member with a category defining a skill that they are willing to share.
offer_need: An offer or a need.  The offer/need can be created an a time-bank other than the one to which you belong. (local admin is notified of external post)
permission: lookup table of extra permissions that may be granted to a member (via member_permissions).
tag: Attaches a tag with either a member (for a skill) or a offer/need (user category).
timebank:  A community time-bank
trade: A transaction between 2 members.  A members balance is the sum of trades for which they are a payee minus the sum of the trades for which they are payees.


